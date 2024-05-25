import React, { useContext } from 'react';
import { TodoContext } from '../context/TodoContext'; // Corrected path

const RenderTodoList = () => {
    const { state, dispatch } = useContext(TodoContext);

    const handleRemove = (itemIndex) => {
        dispatch({ type: 'REMOVE_TODO', payload: itemIndex });
    };

    const handleToggle = (itemIndex) => {
        dispatch({ type: 'TOGGLE_TODO', payload: itemIndex });
    };

    return (
        <div className='todoList'>
            {state.todos.map((list) => (
                <div key={list.itemIndex} className='todoItem'>
                    <input
                        className='checkbox'
                        type='checkbox'
                        checked={list.complete}
                        onChange={() => handleToggle(list.itemIndex)}
                    />
                    <p className='item' style={{ textDecoration: list.complete ? 'line-through' : 'none' }}>
                        {list.todoItem}
                    </p>
                    <button className='btn delete' onClick={() => handleRemove(list.itemIndex)}>
                        Delete
                    </button>
                </div>
            ))}
        </div>
    );
};

export default RenderTodoList;
