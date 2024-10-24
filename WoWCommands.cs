using System.Reflection;

namespace LiesenborghsM
{
    public class WoWCommands
    {

        public WoWCommands(WowInteger wow)
        {
            main = this;
            player = wow;
        }
        public WowInteger player;
        public static WoWCommands main;
        public int spaceStart = 1032;
        public int spaceStop = 2032;
        public int waitingTime = 30000;
        public int makeMoveForward = 1090;
        public int makeStopForward = 2090;
        public int makeMoveBackward = 1083;
        public int makeStopBackward = 2083;
        public int makeStartMoveLeft = 1087;
        public int makeStopMoveLeft = 2087;
        public int makeStartMoveRight = 1088;
        public int makeStopMoveRight = 2088;
        public int makeStartTurnLeft = 1081;
        public int makeStopTurnLeft = 2081;
        public int makeStartTurnRight = 1068;
        public int makeStopTurnRight = 2068;
        public int makeSitOrDown = 1067;
        public int stopSitOrDown = 2067;
        public int startChangeTarget = 1009;
        public int stopChangeTarget = 2009;
        public int startAutoRun = 1086;
        public int stopAutoRun = 2086;
        public int startInteractTarget = 1070;
        public int stopInteractTarget = 2070;
        public int startUsingSpellOne = 1049;
        public int stopUsingSpellOne = 2049;
        public int startUsingSpellTwo = 1050;
        public int stopUsingSpellTwo = 2050;
        public int startUsingSpellThree = 1051;
        public int stopUsingSpellThree = 2051;
        public int startUsingSpellFour = 1052;
        public int stopUsingSpellFour = 2052;
        public int startUsingSpellFive = 1053;
        public int stopUsingSpellFive = 2053;
        public int startUsingSpellSix = 1054;
        public int stopUsingSpellSix = 2054;
        public int startUsingSpellSeven = 1055;
        public int stopUsingSpellSeven = 2055;
        public int startUsingSpellEight = 1056;
        public int stopUsingSpellEight = 2056;
        public int startUsingSpellNine = 1057;
        public int stopUsingSpellNine = 2057;


        public void TurnRight(float seconds)
        {
            TurnRight(player, seconds);
        }
        public void TurnRight(WowInteger wow, float seconds)
        {
            Console.WriteLine("TurnRight");
            PressingForDuration(wow, makeStartTurnRight, makeStopTurnRight, 1, seconds);
        }
        public void TurnLeft(float seconds)
        { TurnLeft(player, seconds); }

        public void TurnLeft(WowInteger wow, float seconds)
        {
            Console.WriteLine("TurnLeft");
            PressingForDuration(wow, makeStartTurnLeft, makeStopTurnLeft, 1, seconds);
        }

        public void MoveForward(float seconds)
        {
            MoveForward(player, seconds);

        }
        public void MoveForward(WowInteger wow, float seconds)
        {
            Console.WriteLine("MoveForward");
            PressingForDuration(wow, makeMoveForward, makeStopForward, 1, seconds);
        }
        public void MoveBackward(float seconds)
        {
            MoveBackward(player, seconds);
        }
        public void MoveBackward(WowInteger wow, float seconds)
        {
            Console.WriteLine("MoveBackward");
            PressingForDuration(wow, makeMoveBackward, makeStopBackward, 1, seconds);
        }
        public void MoveLeft(float seconds)
        {
            MoveLeft(player, seconds);
        }

        public void MoveLeft(WowInteger wow, float seconds)
        {
            Console.WriteLine("MoveLeft");
            PressingForDuration(wow, makeStartMoveLeft, makeStopMoveLeft, 1, seconds);
        }
        public void MoveRight(float seconds)
        {
            MoveRight(player, seconds);
        }

        public void MoveRight(WowInteger wow, float seconds)
        {
            Console.WriteLine("MoveRight");
            PressingForDuration(wow, makeStartMoveRight, makeStopMoveRight, 1, seconds);
        }
        public void SitOrDown(float seconds)
        { SitOrDown(player, seconds); }


        public void SitOrDown(WowInteger wow, float seconds)
        {
            Console.WriteLine("SitOrDown");
            PressingForDuration(wow, makeSitOrDown, stopSitOrDown, 1, seconds);
        }
        public void ChangeTarget(float seconds)
        { ChangeTarget(player, seconds); }

        public void ChangeTarget(WowInteger wow, float seconds)
        {
            Console.WriteLine("ChangeTarget");
            PressingForDuration(wow, startChangeTarget, stopChangeTarget, 1, seconds);
        }
        public void Jump(float seconds)
        { Jump(player, seconds); }

        public void Jump(WowInteger wow, float seconds)
        {
            Console.WriteLine("Jump");
            PressingForDuration(wow, spaceStart, spaceStop, 1, seconds);
        }
        public void InteractTarget(float seconds)
        { InteractTarget(player, seconds); }

        public void InteractTarget(WowInteger wow, float seconds)
        {
            Console.WriteLine("InteractTarget");
            PressingForDuration(wow, startInteractTarget, stopInteractTarget, 1, seconds);
        }
        public void UsingSpellOne(float seconds)
        { UsingSpellOne(player, seconds); }

        public void UsingSpellOne(WowInteger wow, float seconds)
        {
            Console.WriteLine("UsingSpellOne");
            PressingForDuration(wow, startUsingSpellOne, stopUsingSpellOne, 1, seconds);
        }
        public void UsingSpellTwo(float seconds)
        { UsingSpellTwo(player, seconds); }

        public void UsingSpellTwo(WowInteger wow, float seconds)
        {
            Console.WriteLine("UsingSpellTwo");
            PressingForDuration(wow, startUsingSpellTwo, stopUsingSpellTwo, 1, seconds);
        }

        public void UsingSpellThree(float seconds)
        { UsingSpellThree(player, seconds); }

        public void UsingSpellThree(WowInteger wow, float seconds)
        {
            Console.WriteLine("UsingSpellThree");
            PressingForDuration(wow, startUsingSpellTwo, stopUsingSpellTwo, 1, seconds);
        }



        public void ResetTouchZero(WowInteger wow)
        {
            Released(wow, makeStopForward);
            Released(wow, makeStopBackward);

            Released(wow, spaceStop);

            Released(wow, makeStopMoveLeft);
            Released(wow, makeStopTurnLeft);

            Released(wow, makeStopMoveRight);
            Released(wow, makeStopTurnRight);

            Released(wow, stopSitOrDown);

            Released(wow, stopChangeTarget);

            Released(wow, stopInteractTarget);

            Released(wow, stopUsingSpellOne);
        }

        public void PressingForDuration(WowInteger wow, int makeMoveForward, int makeStopForward, int numberOfStep, float second)
        {
            int millisecond = (int)(second * 1000);
            for (int i = 0; i < numberOfStep; i++)
            {
                wow.Push(makeMoveForward);
                Thread.Sleep(millisecond);
                wow.Push(makeStopForward);
            }
        }

        public void Released(WowInteger wow, int released)
        {

            wow.Push(released);

        }

        public void ActionTesting(WowInteger wow)
        {
            Jump(wow, 1);

            TurnRight(wow, 1);
            TurnLeft(wow, 1);

            MoveForward(wow, 1);
            MoveBackward(wow, 1);

            MoveLeft(wow, 1);
            MoveRight(wow, 1);

            SitOrDown(wow, 1);

            ChangeTarget(wow, 1);

            InteractTarget(wow, 1);

            UsingSpellOne(wow, 1);

        }

        public void MoveWithString(string commands, float delay)
        {
            char[] userInput = commands.ToCharArray();
            foreach (char c in userInput)
            {
                Console.WriteLine(c);
                if (c == 'z') MoveForward(delay);
                if (c == 'w') MoveRight(delay);
                if (c == 'x') MoveLeft(delay);
                if (c == 's') MoveBackward(delay);
                if (c == 'q') TurnLeft(delay);
                if (c == 'd') TurnRight(delay);
                if (c == 't') ChangeTarget(delay);
                if (c == '1') UsingSpellOne(delay);
                if (c == '2') UsingSpellTwo(delay);
                if (c == '3') UsingSpellThree(delay);
                if (c == 'f') InteractTarget(delay);
            }
        }
    }
}