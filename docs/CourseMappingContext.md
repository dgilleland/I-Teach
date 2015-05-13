# Course Mapping Context

## High-Level Narrative

At our post-secondary school, **Course Mapping** is a process that each program of study goes through in order to plan out their courses for the diploma/degree/certificate that they offer. It is a collaborative effort, involving instructors and associate program chairs (APCs).

In general, the mapping process begins with proposing a course. During the proposal stage, the name/number of the course along with the course hours, credits, semester, pre-/co-requisites, and list of outcomes are all subject to change. The effect of approving the course can be viewed in an overall map of what the program would look like (listing all the courses and their relationship to each other). Instructors and APCs can participate in designing the course, but typically each course is assigned to a single instructor to enter the details (any APC can make a revision).

For programs where courses already exist, those courses are simply added to the map as is, with all their detailed information. No proposal/approval steps are required.

Existing courses can, however, come under revision. When a course is being revised, it's course number and name remain the same, but details about the number of hours, credits, semester, pre-/co-requisits, and/or the high-level outcomes can be adjusted. When under revision, the original course is usually still be available for students to take, but after the revision is approved (using the same process as for proposed courses) the revised version becomes the "current" course and the previous version is archived.

Sometimes, the edits to a course under revision become significant, so much so that it merits a new course name and course number. In those cases, the revision is redesignated as a new course proposal, with the possibility of replacing some existing course(s) or simply becoming an addition to the course mapping. In those cases, the regular proposal process takes over.

All new proposals and revisions go through similar steps in order to be approved or discarded. Changes are entered to the details of the course; the new course is examined in how it will affect the mapping of current courses; and the new course is either approved or discarded after being given due consideration. In this process, Instructors and APCs can offer their feedback and comments on the new course. Ultimatly, only APCs are allowed to approve or discard a course. Changes in pre- and co-requisites for proposed/revised courses can set up dependency conflicts that must be resolved before a course can be approved. When a course is approved, it's commencement date for the first offering is set. If the course is discarded, a comment is required to provide information on the reason for discarding the course.

Existing courses can also be "sunsetted". A sunsetted course is simply removed from the course map, with its details being archived. A course can be flagged for being sunsetted by entering a date for its planned obsolecense.

Revising or sunsetting an existing course can have an impact on other courses that use the existing course as a pre- or co-requisite. In those cases, the pre-/co-requisite dependencies need to be resolved before a course can actually be archived.

### Career Paths

Some programs of study offer a wide variety of courses with the objective of providing various career path options to students seeking their diploma/degree. In those programs, it's often helpful to map out which elective courses would best prepare students for a particular career path. This career path mapping can occur separate from the course mapping, but often the two mappings will affect each other. In all career path mappings, care must be taken to ensure that students meet the overall requirements of the number of credits and the level of courses to qualify for the diploma/degree.

## Analysis

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
