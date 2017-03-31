using System.Collections.Generic;

namespace InterviewPrep.DesignPatterns
{
    /// <summary>
    /// Factory Method
    /// Creational Patterns
    /// </summary>
    /// 

    class Factory
    {

    }

    abstract class Page
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SkillsPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class EducationPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ExperiencePage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class IntroductionPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ResultsPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConclusionPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class SummaryPage : Page
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class BibliographyPage : Page
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        public abstract void CreatePages();

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Resume
        : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}

/*
            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document d in documents)
            {
                Console.WriteLine("\n " + d.GetType().Name + " --");

                foreach (Page p in d.Pages)
                {
                    Console.WriteLine(" " + p.GetType().Name);
                }
            }

    FACTORY PATTERN:

    Creational Pattern

    Creates objects without exposing the creation of a real instance logic to the client.

    Pros and Cons:
    + Allows you to hide implementation of the core interfaces that make up your application
    + Allows you to change the design of your application more readily (loose coupling)
    - Makes code more difficult to read as all of your code is behind an abstraction 
    that may in turn hide abstractions.

 */

