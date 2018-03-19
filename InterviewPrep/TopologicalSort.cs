using System.Collections.Generic;

namespace InterviewPrep
{
    class TopologicalSort
    {
        public Stack<Project> GetTopologicalOrder()
        {
            List<Project> projects = new List<Project>();
            Stack<Project> stack = new Stack<Project>();

            foreach (var project in projects)
            {
                if (!DPS(project, stack))
                    return null;
            }

            return stack;
        }

        private bool DPS(Project project, Stack<Project> stack)
        {
            // If inprogress true, there is a cycle.
            if (project.DPSState == State.INPROGRESS)
                return false;

            if (project.DPSState == State.BLANK)
            {
                project.DPSState = State.INPROGRESS;

                List<Project> projects = project.GetDependecies;

                foreach (var p in projects)
                {
                    if (!DPS(p, stack))
                        return false;
                }

                project.DPSState = State.COMPLETE;
                stack.Push(project);
            }

            return true;
        }
    }

    enum State { COMPLETE, INPROGRESS, BLANK }

    class Project
    {
        public State DPSState { get; set; }
        private List<Project> Dependencies;
        public int ProjectId { get; }

        public Project(int id)
        {
            ProjectId = id;
            DPSState = State.BLANK;
            Dependencies = new List<Project>();
        }  

        public List<Project> GetDependecies
        { get { return Dependencies; }  }

        public void AddDependencyProject(Project project)
        {
            Dependencies.Add(project);
        }
    }
}
