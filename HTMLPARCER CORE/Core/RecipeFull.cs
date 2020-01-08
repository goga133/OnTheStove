namespace HTMLPARCER_CORE
{
    public class RecipeFull
    {
        public RecipeFull(string webSite, string title, string titlePicture,
            Ingredient[] ingredients, StepRecipe[] stepsOfRecipe, string introductionContent, string endContentText, string[] endContentPictures)
        {
            WebSite = webSite;
            Title = title;
            TitlePicture = titlePicture;
            Ingredients = ingredients;
            StepsOfRecipe = stepsOfRecipe;
            IntroductionContent = introductionContent;
            EndContentText = endContentText;
            EndContentPictures = endContentPictures;
        }

        public string WebSite { get; }
        public string Title { get; }
        public string TitlePicture { get; }
        public Ingredient[] Ingredients { get; }
        public StepRecipe[] StepsOfRecipe { get; }
        public string IntroductionContent { get; }
        public string EndContentText { get; }
        public string[] EndContentPictures { get; }


    }
}