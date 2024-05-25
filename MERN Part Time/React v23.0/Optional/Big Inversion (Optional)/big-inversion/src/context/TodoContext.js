import React, { createContext, useReducer, useEffect } from 'react';

const TodoContext = createContext();

const initialState = {
    todos: JSON.parse(localStorage.getItem('stateString')) || []
};

function todoReducer(state, action) {
    switch (action.type) {
        case 'ADD_TODO':
            return {
                ...state,
                todos: [...state.todos, action.payload]
            };
        case 'REMOVE_TODO':
            return {
                ...state,
                todos: state.todos.filter(todo => todo.itemIndex !== action.payload)
            };
        case 'TOGGLE_TODO':
            return {
                ...state,
                todos: state.todos.map(todo =>
                    todo.itemIndex === action.payload
                        ? { ...todo, complete: !todo.complete }
                        : todo
                )
            };
        default:
            return state;
    }
}

const TodoProvider = ({ children }) => {
    const [state, dispatch] = useReducer(todoReducer, initialState);

    useEffect(() => {
        localStorage.setItem('stateString', JSON.stringify(state.todos));
    }, [state.todos]);

    return (
        <TodoContext.Provider value={{ state, dispatch }}>
            {children}
        </TodoContext.Provider>
    );
};

export { TodoContext, TodoProvider };
