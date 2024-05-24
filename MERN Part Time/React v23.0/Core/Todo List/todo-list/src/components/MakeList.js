import React, { useState } from 'react'

const MakeList = (props) => {
    const { todoArray, setTodoArray } = props;

    const [itemIndex, setItemIndex] = useState(0)
    const [todoItem, setTodoItem] = useState("");
    const [complete, setComplete] = useState(false)

    const handleSubmit = (e) => {
        e.preventDefault();
        setTodoArray([...todoArray,
        {
            itemIndex: itemIndex,
            todoItem: todoItem,
            complete: complete
        }
        ]);
        setItemIndex(itemIndex + 1)
        setTodoItem("");
        setComplete(false)
    }
    return (
        <div className='todoInput'>
            <form onSubmit={handleSubmit}>
                <div >
                    <label htmlFor='todoItem'>Todo Item: </label>
                    <input type="text" name="todoItem" value={todoItem} onChange={(e) => setTodoItem(e.target.value)} />
                    <input className='btn add' type='submit' value="Add" />
                </div>
            </form>
        </div>
    )
}

export default MakeList