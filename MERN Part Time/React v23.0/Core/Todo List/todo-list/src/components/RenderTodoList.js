import React from 'react'

const RenderTodoList = (props) => {
    const { todoArray, setTodoArray } = props;

    const removeTodoItem = (e) => {
        e.preventDefault();
        console.log(e.target.value);
        const newTodo = todoArray.filter(item => item.itemIndex !== Number(e.target.value));
        setTodoArray(newTodo);
    }

    const toggle = (complete) => { return !complete }

    const markComplete = (e) => {
        const updatedArray = todoArray.map(item => (
            item.itemIndex === Number(e.target.value) ?
                { ...item, complete: toggle(item.complete) } :
                { ...item }
        ));
        console.log(updatedArray);
        setTodoArray(updatedArray);
    }

    return (
        <div className='todoList'>
            {
                todoArray.map((list, index) => (
                    <div key={index} className='todoItem'>
                        <input className='checkbox' type='checkbox' value={list.itemIndex} onChange={markComplete}></input>
                        {list.complete === false ?
                            <p className='item'>{list.todoItem}</p> :
                            <p className='item' style={{ textDecoration: "line-through" }}>{list.todoItem}</p>
                        }

                        <button className='btn delete' value={list.itemIndex} onClick={removeTodoItem}>Delete</button>
                    </div>
                ))
            }
        </div>
    )
}

export default RenderTodoList