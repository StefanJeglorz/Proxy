using Proxy.Examples;

Console.WriteLine("Proxy Pattern \n");

ITryCatchProxy tryCatchProxy = new TryCatchProxy();

tryCatchProxy.Try(() =>
{
    Console.WriteLine("Using Try-Catch Proxy without Exception\n");
});

tryCatchProxy.Try(() =>
{
    Console.WriteLine("Using Try-Catch Proxy with Exception");
    throw new Exception("Error Occured");
}, (Exception ex) =>
{
    Console.WriteLine("Invoking custom error handler from Programm.cs Main() Method code");
});

Console.ReadLine();
