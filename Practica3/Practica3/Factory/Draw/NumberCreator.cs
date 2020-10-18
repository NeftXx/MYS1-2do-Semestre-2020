namespace Practica3.Factory.Draw
{
    class NumberCreator
    {
        public static void CreateZero(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point4 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point1.GetInput());
        }

        public static void CreateOne(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y + 10),
                point2 = new BasicNode(intelligentObjects, x + 10, y),
                point3 = new BasicNode(intelligentObjects, x + 10, y + 40);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
        }

        public static void CreateTwo(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point4 = new BasicNode(intelligentObjects, x, y + 20),
                point5 = new BasicNode(intelligentObjects, x, y + 40),
                point6 = new BasicNode(intelligentObjects, x + 30, y + 40);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point6.GetInput());
        }

        public static void CreateThree(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point4 = new BasicNode(intelligentObjects, x, y + 20),
                point5 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point6 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point6.GetInput());
        }

        public static void CreateFour(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x, y + 20),
                point3 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point4 = new BasicNode(intelligentObjects, x + 30, y),
                point5 = new BasicNode(intelligentObjects, x + 30, y + 40);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point5.GetInput());
        }

        public static void CreateFive(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x, y + 20),
                point4 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point5 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point6 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point2.GetInput(), point1.GetInput());
            new Path(intelligentObjects, point1.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point6.GetInput());
        }

        public static void CreateSix(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x, y + 20),
                point4 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point5 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point6 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point2.GetInput(), point1.GetInput());
            new Path(intelligentObjects, point1.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point6.GetInput());
            new Path(intelligentObjects, point6.GetInput(), point3.GetInput());
        }

        public static void CreateSeven(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x, y + 10),
                point3 = new BasicNode(intelligentObjects, x + 30, y),
                point4 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point2.GetInput(), point1.GetInput());
            new Path(intelligentObjects, point1.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
        }

        public static void CreateEight(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x + 30, y),
                point3 = new BasicNode(intelligentObjects, x, y + 20),
                point4 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point5 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point6 = new BasicNode(intelligentObjects, x, y + 40);
            new Path(intelligentObjects, point2.GetInput(), point1.GetInput());
            new Path(intelligentObjects, point1.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point6.GetInput());
            new Path(intelligentObjects, point6.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point4.GetInput(), point2.GetInput());
        }

        public static void CreateNine(SimioAPI.IIntelligentObjects intelligentObjects, int x, int y)
        {
            BasicNode point1 = new BasicNode(intelligentObjects, x, y),
                point2 = new BasicNode(intelligentObjects, x, y + 20),
                point3 = new BasicNode(intelligentObjects, x + 30, y + 20),
                point4 = new BasicNode(intelligentObjects, x + 30, y + 40),
                point5 = new BasicNode(intelligentObjects, x + 30, y);
            new Path(intelligentObjects, point1.GetInput(), point2.GetInput());
            new Path(intelligentObjects, point2.GetInput(), point3.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point4.GetInput());
            new Path(intelligentObjects, point3.GetInput(), point5.GetInput());
            new Path(intelligentObjects, point5.GetInput(), point1.GetInput());
        }
    }
}
