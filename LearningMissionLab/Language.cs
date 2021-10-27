namespace LearningMissionLab
{
    /// <summary>
    /// 
    /// </summary>
    public class Language
    {
        LanguageName _languageName;
        LanguageLevel _languageLevel;
        public Language()
        {
            
        }

        public LanguageName LanguageName { get => _languageName; set => _languageName = value; }
        public LanguageLevel LanguageLevels { get => _languageLevel; set => _languageLevel = value; }
    }
}
