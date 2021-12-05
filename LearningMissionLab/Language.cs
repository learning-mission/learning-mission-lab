namespace LearningMissionLab
{
    /// <summary>
    /// Class: Language
    /// 
    /// Purpose: Provides a model for natural languages
    /// </summary>
    public class Language
    {
        LanguageName _languageName;
        LanguageLevel _languageLevel;
        public Language(LanguageName languageName, LanguageLevel languageLevel)
        {
            this.LanguageName = languageName;
            this.LanguageLevel = languageLevel; 
        }

        public LanguageName LanguageName { get => _languageName; set => _languageName = value; }
        public LanguageLevel LanguageLevel { get => _languageLevel; set => _languageLevel = value; }
    }
}
