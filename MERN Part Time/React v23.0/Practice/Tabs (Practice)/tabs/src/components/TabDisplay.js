import React from 'react'

const TabDisplay = ({ tabArray, tabIndex }) => {
    return (
        <div className="tabDisplay">
            {tabArray[tabIndex].content}
        </div>
    )
}

export default TabDisplay