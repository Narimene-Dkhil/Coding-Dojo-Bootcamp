import React, { useState } from 'react'


function Display(props) {

    const { tasks } = props
    const [updated, setUpdated] = useState(true)

    return (
        <div>
            {tasks.map((t, i) => (
            <div>
                {t.done ? <s> {t.text} </s> : t.text}
                <input type="checkbox" checked={t.done} onChange={(e) => { props.updateTask(i); setUpdated(!updated) }} />
                <button onClick={() => props.deleteTask(i)}>Delete</button>
            </div>
            ))}
        </div>
    );
}

export default Display;