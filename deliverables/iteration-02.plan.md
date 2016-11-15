# Logic Circuit Game

## Iteration 2

 * Start date: Thursday Oct 26st 2016
 * End date: Wednesday Nov 16 2016

## Process

Introduction
This is a summary of the planning group 24 did during the second iteration. We had many additional
discussions on Slack; a social network application. We planned out our implementation for the prototype and distributed roles for working on the prototype

#### Roles & responsibilities

Maria: Tasked to work on the drag-and-drop feature such that gates can be dragged and dropped, and wires can be extended from gate to gate. For now placeholders will be used and the task of integrating the back-end logic to these gameobjects will be delegated to Dylan.

Herman: Tasked with collision detection of wires and gates. Working with Maria, Herman is also tasked with implementing the wire detection system, so that wires can be hooked up gates.
 
Freddy: Tasked with writing the backend code for the objects and interfaces used in the game. More specifically the implementation of levels, wires, gates, and overall simulation. The task of integrating this back-end logic to the gameobjects will be delegated to Dylan.

Mack: Tasked with user account creation and maintenance. Creating accounts with usernames, passwords, the ability to log in and out, and a set of editable and non-editable levels tied to that specific user.

Dylan: Tasked with the final stages of the project, in which he will integrate the front-end (gameobjects) with the back-end (gate logic).


#### Events

We continue following our previous plan: we will have have, at minimum, one face-to-face meeting weekly and to make use of Slack on a consistent basis. We expect face-to-face meetings to either be on Thursday 10-11AM or Friday 2-3PM depending on team availability.
If a face-to-face meeting is not possible, then an online meeting will be held in the form of a group call. These backup meetings will be held during the weekend at a time that is convenient for all group members.

In general, the purpose of these meetings is to go over what has been done and assign general tasks to be completed by the next meeting time. The meetings will also be a knowledge sharing period where team members can help solve any issues of concern other members are having. Smaller decisions will be handled in the group chat over Slack.
 

#### Artifacts

Most of the artifacts used will be the same as the ones used during the previous iteration, and new artifacts have been added to meet team needs. For team organization we will make use of Slack; decisions made over Slack will likely be on topics not concerning direct implementation but more so on scheduling and other team issues. If issues arise regarding implementation details, or other such conflicts, then slack can also be a platform to discuss solutions. General brainstorming and info aggregation will be handled by the use of Google docs. The group editing allowed by Google docs will also assist during weekly meetings if we unable to meet face-to-face. For assigning tasks and tracking progress we will make use of the GitHub issues and the online team-organization application Trello (for more granular tasks). The assignment of these tasks, and their associated priority, will be carried out during either the group meetings or over Slack.

 - Link to issue post with responsibilities for this iteration: https://github.com/csc301-fall-2016/project-team-24/issues/11


## Product

Goals and tasks:

Our primary goal is to complete our prototype (i.e. a basic project which allows users to drag-and-drop gates, hook them up with wires, and run simple simulations). 

To achieve our goals, the following tasks take priority:
(1) To allow the user to create, drag, and drop gates and wires. The creation of gates should allow for multiple duplicates to be made and wires should be flexible enough to connect to any gate on the field. The ability to detect when wires are connected to gates also falls under this task.
(2) To implement backend logic for all of the gates and wires, and be able to simulate it and check whether the result is correct.
(3) Integrate the front-end drag and drop together with the back-end logic so the logic is accurately simulated for a user-placed set of gates and wires.
 
Less important (moreso "stretch" goals this iteration):
(4) Add collision for gates and other draggable logic objects so that there is no unintended overlap in the level.
(5) Add accounts, serialization, and loading from files.
 

Artifacts
   
 - Write up an outline for a typical user walkthrough. We will outline detailed answers to questions like what will the user flow be? How will the user interact with our project? This will aid us while deciding on which implementation features are core to our design

 - We will create the initial basic objects required for our program to function, these include but are not limited to: levels, input/output detectors, logic objects, file readers/writers.
 
 - We will create "model" objects for wires and basic gates which can be connected with other wires and basic gates and properly simulate circuit logic
 
 - We will create a "model" object which holds wires and gates and allows us to simulate inputs on them as if they were real circuits
