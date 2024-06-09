import React, { useState } from 'react';
import TodoItem from './TodoItem';

const TodoList = () => {
    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState('');

    const addTask = () => {
        if (newTask !== '') {
            const task = { text: newTask, completed: false };
            setTasks([...tasks, task]);
            setNewTask('');
        }
    };

    const removeTask = (index) => {
        const updatedTasks = tasks.filter((task, i) => i !== index);
        setTasks(updatedTasks);
    };

    const toggleTaskCompletion = (index) => {
        const updatedTasks = tasks.map((task, i) => {
            if (i === index) {
                return { ...task, completed: !task.completed };
            }
            return task;
        });
        setTasks(updatedTasks);
    };

    return (
        <div>
            <h1>Todo List</h1>
            <ul>
                {tasks.map((task, index) => (
                    <TodoItem
                        key={index}
                        task={task}
                        index={index}
                        toggleTaskCompletion={toggleTaskCompletion}
                        removeTask={removeTask}
                    />
                ))}
            </ul>
            <input
                type="text"
                value={newTask}
                onChange={(e) => setNewTask(e.target.value)}
                placeholder="Add a new task"
            />
            <button onClick={addTask}>Add Task</button>
        </div>
    );
};

export default TodoList;
