using BusinessLayer;


namespace Operation
{
    public class UserProd_Operation
    {
        public List<string> GetCategoryName(List<UserCategory> categories)
        {
            List<string> Names = new List<string>();
            // Get all names of category products
            foreach (UserCategory c in categories)
            {
                Names.Add(c.Name);
            }
            return Names;
        }

        public List<string> GetMealtimeName(List<UserMealtime> mealtimes)
        {
            List<string> Names = new List<string>();
            // Get all mealtime names
            foreach (UserMealtime m in mealtimes)
            {
                Names.Add(m.MealtimeName);
            }
            return Names;
        }

        public (int progM, int progC) GetProgressBar(List<UserMealtime> mealtimes, string mealtimeChoice, string mealtimeChoiceByDefault, string categoryChoice)
        {
            int ProgressBarMT = 0;
            int ProgressBarC = 0;
            foreach (UserMealtime m in mealtimes)
            {
                if (m.MealtimeName == mealtimeChoice || m.MealtimeName == mealtimeChoiceByDefault)
                {
                    foreach (UserCategory uc in m.Categories)
                    {
                        if (uc.Name == categoryChoice)
                        {
                            // get progress bar by category 
                            foreach (UserProduct up in uc.Products)
                            {
                                ProgressBarC += (int)(up.Protein + up.Fats + up.Carbs + up.Calories);
                            }
                            ProgressBarC = ProgressBarC / uc.Products.Count;
                        }

                        // get progress bar by mealtime
                        foreach (UserProduct up in uc.Products)
                        {
                            ProgressBarMT += (int)(up.Protein + up.Fats + up.Carbs + up.Calories);
                        }
                        ProgressBarMT = ProgressBarMT / uc.Products.Count;
                    }
                }
            }
            return (ProgressBarMT, ProgressBarC);   
        }
    }
}