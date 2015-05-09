# Course Mapping Context



![Context Map](Context%20Map.png)

In the domain model of the **Course Mapping** context, there are two aggregate roots: **Course** and **CareerPath**. When operating on the domain, the following commands can be issued:

- **Course** Aggregate Root
  - **Propose New Course** - used to add a draft version of a potential course - such courses can be readily adjusted since they are in the planning stage
  - **Add Existing Course** - requires all the same information as when accepting a proposed course, but skips the proposal stage
  - **Assign Course Number** - can only be done for proposed courses
  - **Assign Course Name** - can only be done for proposed and revised courses
  - **Adjust Course** - can be adjusted for hours, credits, semester, course setting, commencement/final offering date, and whether or not it is to be a core course
  - **Add Course Dependency** - either a Prerequisite or a Corequisite
  - **Adjust Dependency Importance** - change the level of importance for a prerequisite or a corequisite
  - **Remove Course Dependency** - either a Prerequisite or a Corequisite
  - **Accept Proposed Course** - Course information and pre/co-requisites must be complete and a commencement date must be set.
  - **Reject Proposed Course** - scrap a proposed course
  - **Revise Course** - **???** makes a copy of the existing course
    - Some questions on the domain model - how to distinguish a course that is in revision from one that is current, if they are both uniquely identified by the course number? One option is to add a state (proposed, current, revised, archived), and another is to simple add a version number to the course and start it out with a "null" commencement date.
  - **Accept Course Revision** - Course information and pre/co-requisites must be complete and a commencement date must be set.
  - **Reject Course Revision** - scrap a revised course
  - **Retire Course** - Set a final offering date for a course that is slated to be archived
- **Career Path** Aggregate Root
  - **Add Course to Career Path**
  - **Remove Course from Career Path**
  - **Adjust Importance**

![Course Mapping Domain Model](Course%20Mapping%20Domain%20Model.png)
