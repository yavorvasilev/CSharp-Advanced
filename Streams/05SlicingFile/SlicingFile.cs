namespace _05SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SlicingFile
    {
        public static void Main()
        {
            var sourceFile = "video.mp4";
            var resultDirectory = "result.mp4";
            var files = Slice(sourceFile, resultDirectory, 5);
            Assemble(files, resultDirectory);
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
                        //var bytes = Encoding.ASCII.GetBytes(files[i]);
                        //.Write(bytes, 0, bytes.Length);

                        var number = reader.Read(buffer, 0, buffer.Length);
                        while (number != 0)
                        {
                            assembled.Write(buffer, 0, number);
                            number = reader.Read(buffer, 0, buffer.Length);
                        }

                    }

                }
            }
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
    }
}
