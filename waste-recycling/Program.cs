namespace WasteRecycling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garbage[] rottenTomatoes = new Garbage[3];
            for (int i = 0; i < 3; i++)
            {
                rottenTomatoes[i] = new Garbage("rotten tomato nr." + (i + 1));
            }

            PlasticGarbage milkJug = new PlasticGarbage("plastic milk jug", true);

            Dustbin dustbin = new Dustbin("Red red vine");


            for (int i = 0; i < 3; i++)
            {

                dustbin.ThrowOutGarbage(rottenTomatoes[i]);
            }

            PaperGarbage usedTissue = new PaperGarbage("used tissue", false);



            dustbin.ThrowOutGarbage(milkJug);
            dustbin.DisplayContents();



            if (!usedTissue.Squeezed)
            {
                usedTissue.Squeeze();
            }

            dustbin.ThrowOutGarbage(usedTissue);

            Dustbin small = new Dustbin("a small one");

            Garbage[] tooOldBannanas = new Garbage[5];
            for (int i = 0; i < tooOldBannanas.Length; i++)
            {
                tooOldBannanas[i] = new Garbage("black bananna " + (i + 1));
            }

            foreach (var bananna in tooOldBannanas)
            {
                small.ThrowOutGarbage(bananna);
            }

            PlasticGarbage emptyBottle = new PlasticGarbage("empty bottle", false);

            emptyBottle.Clean();
            System.Console.WriteLine("This bottle is clean - " + emptyBottle.Cleaned);

            dustbin.ThrowOutGarbage(emptyBottle);

            small.ThrowOutGarbage(usedTissue);

            small.DisplayContents();

            dustbin.DisplayContents();
        }
    }
}
