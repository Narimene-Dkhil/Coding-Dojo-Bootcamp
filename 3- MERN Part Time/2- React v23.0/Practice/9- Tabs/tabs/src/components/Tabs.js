import React from 'react'

const Tabs = ({ tabArray, tabIndex, setTabIndex }) => {

    const updateTabIndex = (e) => {
        e.preventDefault();
        setTabIndex(e.target.value);
    }
    return (
        <div className='tab'>
            <div className='allTabLabels'>
                {tabArray.map((list, index) => (
                    <div key={index} >
                        {index === Number(tabIndex) ?
                            <button className='tabLabel tabSelected' value={index} onClick={updateTabIndex}>{list.label}</button> :
                            <button className='tabLabel' value={index} onClick={updateTabIndex}>{list.label}</button>}
                    </div>
                ))
                }
            </div>
            <div className="tabDisplay">
                {tabArray[tabIndex].content}
            </div>
        </div>
    )
}

export default Tabs