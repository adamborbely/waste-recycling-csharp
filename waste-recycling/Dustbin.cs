using System;


namespace WasteRecycling
{
    public class Dustbin
    {
        public string Color;
        public PaperGarbage[] PaperContent;
        public PlasticGarbage[] PlasticContent;
        public Garbage[] HouseWasteContent;

        public Dustbin(string color)
        {
            Color = color;
            PaperContent = new PaperGarbage[0];
            PlasticContent = new PlasticGarbage[0];
            HouseWasteContent = new Garbage[0];
        }

        private int Cointains(Garbage[] garbages)
        {
            int result = garbages.Length;
            foreach (var elem in garbages)
            {
                if (elem == null)
                {
                    result--;
                }
            }
            return result;
        }

        public void DisplayContents()
        {
            System.Console.WriteLine(Color + " Dustbin!");
            System.Console.WriteLine();
            System.Console.WriteLine(@"House waste content: {0} item(s)", Cointains(HouseWasteContent));
            System.Console.WriteLine();
            if (HouseWasteContent.Length > 0)
            {
                foreach (var elem in HouseWasteContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine(@"Paper content: {0} item(s)", Cointains(PaperContent));
            System.Console.WriteLine();
            if (PaperContent.Length > 0)
            {
                foreach (var elem in PaperContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine(@"Plastic content: {0} item(s)", Cointains(PlasticContent));
            System.Console.WriteLine();
            if (PlasticContent.Length > 0)
            {
                foreach (var elem in PlasticContent)
                {
                    if (elem != null)
                    {
                        System.Console.WriteLine(elem.Name);
                    }
                }
            }
        }
        public void ThrowOutGarbage(Garbage garbage)
        {
            if (garbage is PlasticGarbage)
            {
                PlasticGarbage plastic = (PlasticGarbage)garbage;

                if (plastic.Cleaned)
                {
                    Array.Resize(ref PlasticContent, +1);
                    PlasticContent[PlasticContent.Length - 1] = plastic;
                }
                else
                {
                    throw new DustbinContentException("Plastic is dirty!");
                }
            }
            else if (garbage is PaperGarbage)
            {
                PaperGarbage paper = (PaperGarbage)garbage;
                if (paper.Squeezed)
                {
                    Array.Resize(ref PaperContent, +1);
                    PaperContent[PaperContent.Length - 1] = paper;
                }
                else
                {
                    throw new DustbinContentException("The paper need to be squezzed first!");
                }
            }
            else if (garbage is Garbage)
            {
                Array.Resize(ref HouseWasteContent, +1);
                HouseWasteContent[HouseWasteContent.Length - 1] = garbage;
            }
            else
            {
                throw new DustbinContentException("That is some gold you wanna throw out!");
            }

        }

        public void EmptyContents()
        {

            this.PaperContent = new PaperGarbage[0];
            this.PlasticContent = new PlasticGarbage[0];
            this.HouseWasteContent = new Garbage[0];

        }

    }

}
