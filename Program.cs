using System;
using System.Text;
using System;
using LiesenborghsM;

partial class Program
{
    public static void MidiNoteDetected(int key, bool isDown) {

        Console.WriteLine($"Key: {key}, Down {isDown}");
        float secondspress = 0.3f;
        switch ( key )
        {
            case 53: LiesenborghsM.WoWCommands.main.MoveLeft(secondspress); break;
            case 54: WoWCommands.main.ChangeTarget( secondspress); break;
            case 55: WoWCommands.main.TurnLeft( secondspress); break;
            case 56: WoWCommands.main.MoveForward(secondspress); break;
            case 57: WoWCommands.main.TurnRight( secondspress); break;
            case 58: WoWCommands.main.InteractTarget( secondspress); break;
            case 59: WoWCommands.main.MoveRight( secondspress); break;
            case 16: WoWCommands.main.UsingSpellOne( secondspress); break;
            case 17: WoWCommands.main.UsingSpellTwo( secondspress); break;
            case 18: WoWCommands.main.UsingSpellThree( secondspress);break;




        }

    }


    static void Main(params string[] parameters)
    {
        float i = 4;
        Console.WriteLine("" + i.GetType());
        string name = "Mathias";
        Console.WriteLine($"Bonjour {name}");

        ListenToMidi midi = new ListenToMidi();
        midi.AddUpDownListener(MidiNoteDetected);
        string ipv4 = "192.168.137.50";
        int port = 7073;
        int teamIndex = 4;
        if (parameters.Length >= 1) ipv4 = parameters[0];
        if (parameters.Length >= 2) port = int.Parse(parameters[1]);
        if (parameters.Length >= 3) teamIndex = int.Parse(parameters[2]);

        //Add the ip of the teacher local computer.
        //Documentation:
        //https://github.com/EloiStree/2024_08_29_ScratchToWarcraft

        WowInteger wow = new WowInteger(teamIndex, ipv4, port);
        WoWCommands commands = new WoWCommands(wow);
        commands.ResetTouchZero(wow);

        while (true)
        {
            Console.WriteLine("next ?");
            string woWCommands = Console.ReadLine();
            bool isTurnLeft = (woWCommands == "7");

            if (woWCommands == "Attaque")
                commands.MoveWithString("t121212f", 2);
            else if (woWCommands == "Loop")
            { 
             while (true)
                {
                    commands.MoveWithString("dt121212f", 2);
                }
            }
            else
                commands.MoveWithString(woWCommands, 0.2f);

            if (isTurnLeft)
            {
                commands.TurnLeft(wow, 0.2f);
            }

            if (woWCommands == "5")
            {
                commands.Jump(wow, 0.5f);
            }

            if (woWCommands == "9")
            {
                commands.TurnRight(wow, 0.2f);
            }

            if (woWCommands == "8")
            {
                commands.MoveForward( 0.5f);
            }

            if (woWCommands == "4")
            {
                commands.MoveLeft(wow, 0.5f);
            }

            if (woWCommands == "6")
            {
                commands.MoveRight(wow, 0.5f);
            }

            if (woWCommands == "2")
            {
                commands.MoveBackward(wow, 0.5f);
            }

            if (woWCommands == "e")
            {
                commands.InteractTarget(wow, 1f);
            }

            if (woWCommands == "a")
            {
                commands.ChangeTarget(wow, 1f);
            }

            if (woWCommands == "&")
            {
                commands.UsingSpellOne(wow, 1f);
            }

            if (woWCommands == "é")
            {
                commands.UsingSpellTwo(wow, 1f);
            }

            if (woWCommands == "#")
            {
                commands.UsingSpellThree(wow, 1f);
            }

        }


                //commands.ActionTesting(wow);



        //while (true)
        //{
        //    wow.Push(spaceStart);
        //    Console.WriteLine("Jump");
        //    Thread.Sleep(waitingTime);
        //    wow.Push(spaceStop);
        //    Thread.Sleep(waitingTime);
        //}


    }

    


}
