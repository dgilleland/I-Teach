# Course Mapping Context

In the domain model of the **Course Mapping** context, there are two aggregate roots: **Course** and **CareerPath**. When operating on the domain, the following commands can be issued:

- **Course** Aggregate Root
  - **Propose New Course**
  - **Add Current Course**
  - **Assign Course Number**
  - **Assign Course Name**
  - **Adjust Course** - can be adjusted for hours, credits, semester, course setting, commencement/final offering date, and is core course
  - **Accept Proposed Course**
  - **Revise Course**
  - **Accept Course Revision**
  - **Retire Course**
- **Career Path** Aggregate Root
  - **Add Course to Career Path**
  - **Remove Course from Career Path**
  - **Adjust Importance**
