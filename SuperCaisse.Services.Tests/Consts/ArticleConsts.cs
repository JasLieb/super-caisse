using SuperCaisse.Model;

namespace SuperCaisse.Services.Tests
{
    public class ArticleConsts
    {
        public static Article Screwdriver =>
            new Article("Tournevis", "01010", Categories.Tools, 14.99);

        public static Article Probe =>
            new Article("Sonde", "10101", Categories.Tools, 49.99);

        public static Article WoodenGardenChair =>
            new Article("Chaise en bois de jardin", "11111", Categories.Garden, 25);

        public static Article RJ45Cable3Meters =>
            new Article("Cable RJ45 3m", "11001", Categories.Electronic, 7.5);
    }
}
