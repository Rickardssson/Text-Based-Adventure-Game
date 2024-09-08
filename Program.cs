class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("You find yourself in a bar and see the bartender aproach you.");
        string name = "";

        do
        {
            name = Ask("What's your name kid? ");
        } while (!AskYesOrNo($"{name} is it? "));
    }

    static string Ask(string question)
    {
        string response = "";
        while (response == "")
        {
            Console.Write(question);
            response = Console.ReadLine().Trim();
        }

        return response;
    }

    static bool AskYesOrNo(string question)
    {
        while (true)
        {
            string response = Ask(question).ToLower();
            switch (response)
            {
                case "yes":
                    case "ok":
                    return true;
                case "no":
                    return false;
            }
        }
    }
        
}
