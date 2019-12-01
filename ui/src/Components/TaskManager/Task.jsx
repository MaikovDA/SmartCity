import React from 'react';
import Man_icon from '../../assets/Man_icon.png'
import Icon from '../../assets/Icon.png'
import Edit from '../../assets/Edit.png'
import Delete from '../../assets/Delete.png'
import clean_work from '../../assets/clean_work.png'
import snow_work from '../../assets/snow_work.png'
import water_work from '../../assets/water_work.png'
import sprinkl_work from '../../assets/sprinkl_work.png'
import '../../Styles/Tasks.scss'

const Task = (props) => {
  const { task: { id, status_type }, activeTask, edited, showPopup, onClick } = props;

  return (
    <div 
      className={`task-item ${id === activeTask ? 'active' : ''} `} 
      data-id={id}
    >
      <div className="left-column">
        <div className="text">
          Центральный проезд Хорошёвского - Серебряного Бора
        </div>
        <div className="work_types">
          <img src={clean_work} alt="" />
          <img src={snow_work} alt="" />
          <img src={water_work} alt="" />
          <img src={sprinkl_work} alt="" />
        </div>
      </div>
      <div className="middle-column">
        <div className="distantion">8,3 км</div>
        <div className="people">12 <img src={Man_icon} alt=""/></div>
        <div className="time">2ч 35мин</div>
      </div>
      {
        edited &&
        <div className="right-column">
          <div className="button delete-button">
            <img src={Delete} alt="" />
          </div>
          <div className="button edit-button" onClick={props.showPopup}>
            <img src={Edit} alt="" />
          </div>
          <div className="button icon-button">
            <img src={Icon} alt="" />
          </div>
        </div>
      }
    </div>
  )
}

export default Task;