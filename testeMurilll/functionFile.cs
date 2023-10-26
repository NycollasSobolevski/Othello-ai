using System;
using System.IO;

public class FileClass
{
    public string Read(string FilePath)
    {
        if (File.Exists(FilePath))
        {
            string conteudo = File.ReadAllText(FilePath);
            Console.WriteLine(conteudo);

            return conteudo;
        }

        return "Arquivo não encontrado.";
    }
}