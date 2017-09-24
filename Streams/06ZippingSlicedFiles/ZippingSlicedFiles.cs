namespace _06ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;


    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            var sourceFile = "video.mp4";
            var resultDirectory = "result.gz";
            var files = Slice(sourceFile, resultDirectory, 5);
            var filesGz = Compress(files);
            Assemble(filesGz, resultDirectory);
        }


        private static void Assemble(List<string> files, string resultDirectory)
        {
            var buffer = new byte[4096];

            using (var assembled = new FileStream(resultDirectory, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var reader = new FileStream(files[i], FileMode.Open);
                    using (reader)
                    {
                        var number = reader.Read(buffer, 0, buffer.Length);
                        while (number != 0)
                        {
                            assembled.Write(buffer, 0, number);
                            number = reader.Read(buffer, 0, buffer.Length);
                        }

                    }

                }
            }
            Decompress(resultDirectory);
        }

        private static List<string> Slice(string sourceFile, string resultDirectory, int parts)
        {
            var bufferSize = new byte[4096 * 5];

            var listOfFiles = new List<string>();

            using (var inputStream = new FileStream(sourceFile, FileMode.Open))
            {
                var index = 1;

                var partSize = (int)Math.Ceiling((double)inputStream.Length / parts);

                while (inputStream.Position < inputStream.Length)
                {
                    using (var outputStream = new FileStream(string.Format("{0}part{1}.mp4", resultDirectory, index), FileMode.Create))
                    {
                        listOfFiles.Add(outputStream.Name);
                        var bytesRead = 0;

                        while (bytesRead < partSize)
                        {
                            var bytes = inputStream.Read(bufferSize, 0, (int)Math.Min(partSize - bytesRead, bufferSize.Length));

                            if (bytes == 0)
                            {
                                break;
                            }

                            outputStream.Write(bufferSize, 0, bytes);

                            bytesRead += bytes;
                        }
                    }
                    index++;
                }
            }
            return listOfFiles;

        }

        private static void Decompress(string inputFile)
        {
            var outputFile = "DecompressedVideoFile.mp4";

            using (var inputStream = new FileStream(inputFile, FileMode.Open))
            {
                using (var compressionStream = new GZipStream(inputStream, CompressionMode.Decompress, false))
                {
                    using (var outputStream = new FileStream(outputFile, FileMode.Create))
                    {
                        var buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressionStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            outputStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        public static List<string> Compress(List<string> inputFiles)
        {
            var resultFilesGz = new List<string>();

            for (int i = 0; i < inputFiles.Count; i++)
            {
                var inputFile = inputFiles[i];
                var outputFile = $"Part-{i}.gz";

                using (var inputStream = new FileStream(inputFile, FileMode.Open))
                {
                    using (var outputStream = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(outputStream, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[4096];
                            while (true)
                            {
                                int readBytes = inputStream.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                compressionStream.Write(buffer, 0, readBytes);
                            }
                            resultFilesGz.Add(outputStream.Name);
                        }
                    }
                }
            }
            return resultFilesGz;
        }
    }
}
