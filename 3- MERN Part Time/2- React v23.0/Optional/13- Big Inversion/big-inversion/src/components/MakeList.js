import React, { useState, useContext } from 'react';
import { TodoContext } from '../context/TodoContext'; // Corrected path

const MakeList = () => {
    const { state, dispatch } = useContext(TodoContext);

    const [todoItem, setTodoItem] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        dispatch({
            type: 'ADD_TODO',
            payload: {
                itemIndex: state.todos.length > 0 ? state.todos[state.todos.length - 1].itemIndex + 1 : 0,
                todoItem,
                complete: false
            }
        });
        setTodoItem('');
    };

    return (
        <div className='todoInput'>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor='todoItem'>Todo Item: </label>
                    <input
                        type='text'
                        name='todoItem'
                        value={todoItem}
                        onChange={(e) => setTodoItem(e.target.value)}
                    />
                    <input className='btn add' type='submit' value='Add' />
                </div>
            </form>
        </div>
    );
};

export default MakeList;
