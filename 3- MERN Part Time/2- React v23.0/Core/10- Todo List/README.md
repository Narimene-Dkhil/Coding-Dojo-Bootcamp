# Todo List
Ah, the todo list! A ubiquitous project for any respectable JavaScript framework. Your job is to create a small React application to store and modify a list of tasks. Each task will have a text string as well as a completed property, which will be set to false initially. As you check off items, they should appear slashed out on the page. Using what you know about state and iterating through lists, render a list of items, and give the user the option to remove each item and add new ones. There are different ways to implement the remove function. One way to do it is using the [built-in filter method](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/filter). Filter returns a new array when invoked and is a great way to stay true to the functional nature of React.

Hint: When updating the state, make sure to send in a brand new object or array; otherwise React won't update the view.

![Image](image.png)

## Requirements:

- Iterate through the existing tasks using the map method.
- Allow the user to add a new task, initially set to not completed.
- Allow the user to remove a task by clicking the delete button.
- Allow the user to toggle a task's completion property by clicking the checkbox next to it.
- Ninja Bonus: When updating the tasks' state, don't mutate the current task objects or the current task list.
- Sensei Bonus: Persist the todos list on page refreshes. Hint, consider combining the browser's localStorage with the useEffect hook.