# Logic Circuit Game

## Iteration 1 - Review & Retrospect

 * When: TODO
 * Where: TODO

### Summary of Meetings

#### Meeting 1
 * When: Friday Oct 28th 2016
 * Where: In person in BA3200
 * What: The purpose of the meeting was to discuss project implementation. We were able to design the various user paths as well as hash out many of the systems we wish to put in place. [Implementation Structure][Implementation Structure]

#### Meeting 2
 * When: Friday Nov 4th 2016
 * Where: In person in BA2200
 * What: The purpose of this meeting was to do any last minute corrects or clarifications before we began development over the weekend. 

#### Meeting 3
  * When: Thursday Nov 11th 2016
  * Where: In person in BA3200
  * What: The purpose of this meeting was to touch base after a weekend of implementation. We discussed what had been done and what we needed to do moving forward. 

#### Meeting 4
  * When: Tuesday Nov 15th 2016
  * Where: In person in BA3200
  * What: we reviewed everything we've done this iteration. We discussed the last touches we needed to make to our project as well as how we are going to make the video

## Process - Reflection

In general, many things were changed, responsiblities and tasks were shifted, but generally most goals were met.

Decisions that turned out well:

- The addition of an extra team meeting slot resulted in an increase of team meetings and an increase in communication. With the increase in communication, conflicts were flagged and dealt with in a quicker fashion.

- the use of slack continued to be of great help in all aspects of the development process. Planning meetings, flaggin errors, asking for assistance, all these issues were easily resolved in the group forums of slack.

Decisions that did not turn as well as we hoped:

- We made the decision to change to 2D modeling from 3D. whilst integrating the front-end and the backend it came to our attention that future work (in terms of aesthetics) would become easier if we switched to a 2D model. refractoring the code took some time.

- We had to change a core design feature, namely the account system. Whilst starting work on the serialization aspect of the program (an aspect which was tied in heavily with the account system) it came to our attention that accounts were not neccessary to fulfil the goals of the program and thus Mack's responsibilities were shifted away from the account system and towards implementing a different form of serialzation.

- We also focused too much on backend work that wasn't relivent to our iteration-2 demo. While all the work we did needed to get done eventually, we didn't have the ablility to properly demo all of our progress.

- The team organization application Trello was not used to its full capacity. Though this was made up for by an increased number of team meetings and increased communication over slack.

We are planning to make the following changes to our process:

- Communicate and plan more throughly so that priorities are properly set and deadlines for key features are met.

## Product - Review

Goals/tasks that were met/completed:

- Drag and drop features were implemented. Gates can be cloned from a "model" gate and dragged and dropped anywhere on the map, Wires can be used to connect gates, and gates have areas in which placed wires can be detected.
- The logic and back-end implementation was completed. The Appropriate interfaces were created and the necessary logic was implemented.
- Level serialization and deserialzation was completed. made use of JSON to save levels locally.
- integrated the front-end with the back-end.

Goals/tasks that were planned but not met/completed:

- We did not produce a "typical user walkthrough" artifact as we previously intended. Instead we switched to a more brainstorming method to determine the details of our implementation. This saved us time and allowed for more detailed aspects of the program to be brought to light.

Going into the next iteration, our main insights are:

- Get everybody on the same page in terms of where the product needs to go
- Make sure everyone becomes familiar with the differences of the new 2D engine
- make the product more aesthetically pleasing (After implementation is dealth with)

Product artifacts that we produced this iteration:
 * [Implementation Structure][Implementation Structure] - The structure of our program in terms of Implementation. 

[Implementation Structure]: https://docs.google.com/document/d/1t1vzYvifu1viiE6vm9i3t4oosKgifU6RrB5jUNmpuho/edit
