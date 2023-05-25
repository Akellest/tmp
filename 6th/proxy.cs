interface IFile
{
    void Open();
}

class File : IFile
{
    private string filePath;

    public File(string filePath)
    {
        this.filePath = filePath;
    }

    public void Open()
    {
        Console.WriteLine($"Opening file: {filePath}");
    }
}

class FileProxy : IFile
{
    private string filePath;
    private IFile file;

    public FileProxy(string filePath)
    {
        this.filePath = filePath;
    }

    public void Open()
    {
        if (CanAccessFile())
        {
            if (file == null)
            {
                file = new File(filePath);
            }

            Console.WriteLine("Access is allowed");
            file.Open();
        }
        else
        {
            Console.WriteLine("Access denied");
        }
    }

    private bool CanAccessFile()
    {
        return true; // доступ разрешен всем
    }
}

class Program
{
    static void Main(string[] args)
    {
        IFile fileProxy = new FileProxy("file.txt");
        fileProxy.Open();
    }
}
