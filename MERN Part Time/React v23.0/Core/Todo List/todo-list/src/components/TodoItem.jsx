import React from 'react';

const TodoItem = ({ task, index, toggleTaskCompletion, removeTask }) => {
    const handleCheckboxChange = () => {
        toggleTaskCompletion(index);
    };

    const handleRemoveClick = () => {
        removeTask(index);
    };

    return (
        <li style={{ textDecoration: task.completed ? 'line-through' : 'none' }}>
            <input
                type="checkbox"
                checked={task.completed}
                onChange={handleCheckboxChange}
            />
            {task.text}
            <button onClick={handleRemoveClick}>Delete</button>
        </li>
    );
};

export default TodoItem;
