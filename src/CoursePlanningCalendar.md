# Course Planning Calendar

In DMIT, we plan how we are going to deliver our courses and course offerings on a regular basis. Every term, a Planning Calendar is created for each course to organize the topics that will be covered and the exam/lab dates. During Intercession, the overall topic flow is planned and settled on, along with the week in which exams and labs will be released and due. Then, at the very start of the term, specific dates for exams and labs will be chosen based on the various schedules for the sections of the course offering.

## Simplest Possible Thing

As an instructor, I want a way to organize my weekly topics for a course along with their evaluation components (buckets, labs, exams, etc.). I want to be able to share this planning calendar with other instructors for the course and then publish it for the students to see at the start of the term. I may need to make adjustments to the planning calendar one or more times as the course progresses, for various reasons. In general, all the instructors try to start with the same planning calendar, but they may diverge slightly as the course progresses.

Each course is 15 weeks long. Planning calendars can be copied/applied to various terms (e.g.: Fall 2014 or Winter 2015) and sections.

Things to test:
- UI – manual testing (ignore automated testing for now)
  - Enter/edit topics/evaluation components for each week
  - Reorder topics/evaluations
  - Bulk-save the changes to the planning calendar
- Domain – 
  - A course will have at most one current planning calendar and zero or more previous calendars. A planning calendar lists a week-by-week or class-by-class plan of topics along with any evaluation components (labs, exams, etc.) that will occur over the term. It is not unusual for topics to span more than one class or week; that is, a topic can have an estimated duration (in terms of days or class periods), though it is not required for placing the topic on the calendar.
  - An active planning calendar is one that is being used for one or more sections of a specific course offering by an instructor. Instructors are allowed to make modifications to the planning calendars for their sections, but should do so in consultation with other instructors, particularly in regard to changing the dates of any evaluation components.
  - Events
    - Add Course
    - Create Planning Calendar
    - Modify Planning Calendar
      - Add Topic
      - Reorder Topics
    - Apply Planning Calendar to Course Offering
    - Publish Planning Calendar
    - Assign Dates to Evaluation Components
    - Modify Active Planning Calendar
    - Link Topic to Resources (notes, readings, etc.)

Topics on the Planning Calendar are short descriptions of what is being covered at a particular point in the course. Students only need to see those short topic names, but as Instructors we would benefit from including additional details on the topics. Those details might consist of things such as a list of key points or objectives, comments about the topic, notes about the in-class examples to be used or the scenarios to be used for testing (labs/exams), etc. This extra information can be helpful in planning the sequence of the topics and also help the instructor in remembering important aspects of the topic when it comes time to teach it in class.
