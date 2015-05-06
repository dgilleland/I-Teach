<style type="text/css">
    .auto-style1
    {
        text-decoration: underline;
    }
</style>

# ASchool Business Rules - Idea Bucket

The business rules here are in "idea" format and exploratory. Once they are clearly worded and accompanied by an example (sample data), then they can be accepted and put into formal Acceptance Test format (Gherkin).

> A note on writing Business Rules and Requirements. I've read in a number of places how it's important to try and strip out language and terminology that has nothing to do specifically with the "language domain" of the business. For example, talking about "when they click a button" or "then the database should" is talking more about the technology rathern than the business. That kind of terminology might be good for narrow unit-tests that get into nitty-gritty internals, but all the "big picture" requirements should just stick to the business' Language Domain.

*   **General**
    *   All stories involve some kind of "workflow" - a way in which data moves from one state to another.
    *   Each "workflow" has its own set of rules
    *   Business rules can be shared among workflows within a given story.
    *   Business rules are not shared among different stories; by virtue of being in a different story, it represents a different rule by definition, because the story is the context for each business rule.
    *   Stories represent definable sets of data (tables/objects)
        *   (? - uncertain) This data may participate in multiple stories in a read-only fashion and undergo [significant] editing in only one story (their primary story)

----

*   **Managing Course Grid** Story
    *   General
        *   The only acceptable course statuses are "Proposed", "Current", and "Revision". These statuses are intended to represent a maintenance workflow.(Archiving a course involves removing it from the set of courses, but retaining the information for historical purposes.)
            *   <span class="auto-style1">Proposed</span> - For new courses that are to be assigned a new course number (as opposed to a revision of a course that will be keeping its Course Number)
            *   <span class="auto-style1">Current</span> - For courses that are approved and complete in their information; Current courses are available for scheduling as an offering for any date after the Commencement Date and (if present) before the Completion Date
            *   <span class="auto-style1">Revision</span> - For existing courses that are undergoing a significant change, such as the number of credits, hours, semester, course dependencies, Academic path mapping, etc.![](Course%20Development%20Cycle.png)
        *   A course may be added either as Proposed or Current (provided all other requirements are followed).
        *   Two courses cannot have identical course numbers unless one course's status is "Current" and the other's is "Revision" (This allows a course to be under revision for changes)
            *   You can only have one Revision of a Current course at any one time
        *   Course must maintain information to know "when" a course is available for being a course offering
            *   <span class="auto-style1">Approval Date</span> - The date on which a course's status moved to "Current"
            *   <span class="auto-style1">Commencement Date</span> - The date on which a current course is slated to be available as a Course Offering
            *   <span class="auto-style1">Completion Date</span> - The date on which a current course is to be removed (archived)

    *   Proposed Courses
        *   You can add a course with minimal information (name, credits, class hours per week) provided it's status is "Proposed".
        *   The CourseNumber for a course can only be changed when the course is in a "Proposed" state; it cannot be changed when the course's state is Current or Revision
        *   A new course with a "Proposed" status but without a CourseNumber is given a temporary course number of "PROPOSED-###" where the number generated is one higher than the highest proposed course number saved at present
        *   Courses in a "Proposed" state cannot have a Approval Date, Commencement Date or Completion Date
        *   Any information in a "Proposed" course can be edited, provided the minimal amount of information is still maintained.
        *   Course Dependencies can only be edited/changed/removed if at least one of the courses in the dependency is in the "Proposed" status
        *   Courses can only be mapped to Academic Paths if the Course Status is Proposed
        *   Proposed courses can be deleted, but they cannot be archived

    *   Current Courses
        *   The minimal information for a course to be "Current" is
            *   Course Name
            *   Course Number
            *   Credits
            *   Class Hours Per Week
            *   Term
            *   Semester Offered
        *   An existing course can have its status changed from "Proposed" to "Current" provided all the course information has been entered
        *   An existing course can have its status changed from "Revision" to "Current" provided all the course information has been entered
        *   When a course status is moved to "Current", it must also be given an Approval Date and a Commencement Date
        *   A course with its status set to "Current" cannot be changed in any way, except to have its Completion Date set or to be Archived
        *   Only "Current" courses can be archived, provided they have a Completion Date set and the Completion Date has passed

    *   Revision Courses
        *   Only "Current" courses can be slated for "Revision"; when slated for Revision, the Current course is copied (except for the Approval Date, Commencement Date, and Completion Date) and the copy is set as a "Revision"
        *   Revisions can be deleted, but they cannot be archived

    *   Archiving
        *   Courses that are slated for "sunsetting" (given a Completion Date) must be maintained in an archive storage for historical purposes.

    *   Course Dependencies
        A course dependency occurs where two or more courses are expected to be taken in "sequence" or in "parallel". The courses form a type of **Relationship** and **Connection** to each other. A dependency chain is the complete linkage between courses (A→B↔C→D→E).
        *   The two types of Relationships possible between courses are <span class="auto-style1">**Prerequisite**</span> and <span class="auto-style1">**Corequisite**</span>
            *   "Prerequisite" - (A → B) The courses are to be taken as a sequence, where one course must be completed **before** the other can be taken
            *   "Corequisite" - (A ↔ B) The courses are to be taken in parallel, **at the same time**
        *   When describing pre-/co-requisites, the second course is said to "depend upon" the first course. In these examples, B depends upon A.
            *   A→B
            *   A↔B
        *   Corequisite relationships are not necessarily "bi-directional". Eg.:
            *   When stating that A↔B (that is, course B needs A), that does not mean that B↔A (course A needs B). Essentially, course A may stand independent of other courses, while B has a dependency
        *   Prerequisite courses cannot have a circular relationship. Eg: These are not allowed:
            *   A before B; B before A
            *   A before B, B before C, C before A
        *   Corequisite courses can have a circular relationship. Eg: The following is allowed
            *   A at the same time as B, B at the same time as A
        *   Indirect circular relationships are not allowed. An indirect circular relationship occurs when prerequisite and corequisite relationships combine in a particular way.
            _(Note: Dependency chains may be complex; care must be taken to ensure that indirect circular relationships are not created between courses. The best way to resolve a dependency chain for a circular dependency is to "walk" the dependencies for each course, looking for a duplicate)_
            *   Eg: These are not allowed.
                *   A before B, B at the same time as C, C before A
                *   A→B, B↔C, C→D, D↔A

                    <table>

                    <tbody>

                    <tr>

                    <td>A</td>

                    <td>→</td>

                    <td>B</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td>B↔C</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td>C</td>

                    <td>→</td>

                    <td>D</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td>D↔A</td>

                    <td>Impossible</td>

                    </tr>

                    </tbody>

                    </table>

                *   A→B, B↔C, C→D, A↔D

                    <table>

                    <tbody>

                    <tr>

                    <td>A</td>

                    <td>→</td>

                    <td>B</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td>B↔C</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td style="text-align:right">C</td>

                    <td>→</td>

                    <td>D</td>

                    <td>Possible</td>

                    </tr>

                    <tr>

                    <td>A</td>

                    <td>↔</td>

                    <td>D</td>

                    <td>Impossible</td>

                    </tr>

                    </tbody>

                    </table>

            *   Eg.: This would be allowed

            *   A→B, B↔C, C↔D, A→D

                <table>

                <tbody>

                <tr>

                <td>A</td>

                <td>→</td>

                <td>B</td>

                <td>Possible</td>

                </tr>

                <tr>

                <td>B↔C</td>

                <td>Possible</td>

                </tr>

                <tr>

                <td style="text-align:right">C</td>

                <td>↔</td>

                <td>D</td>

                <td>Possible</td>

                </tr>

                <tr>

                <td>A</td>

                <td>→</td>

                <td>D</td>

                <td>Possible</td>

                </tr>

                </tbody>

                </table>

        *   The connection between courses can have two strengths: **Required** (a "*must be*" connection) or **Suggested** (a "*may be*" connection).
            *   "Required" prerequisite: A **_must be_** before B
            *   "Required" corequisite: A **_must be_** at the same time as B
            *   "Suggested" prerequisite: A **_may be_** before B
            *   "Suggested" prerequisite: A **_may be_** at the same time as B

----

*   **Managing Academic Paths** Story
    (An Academic Path may be something like a set of courses that fit with a particular career goal or that lead to another level of academic studies such as post-secondary (for high-school courses) or a Masters (for university degrees))

----

*   **Managing Course Offerings** Story

----

*   **Managing Course Locations** (Rooms) Story
