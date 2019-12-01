import React, { Component, Fragment } from 'react';
import '../Styles/TasksList.scss';
import { connect } from 'react-redux';
import Actions from '../reducers/Actions';
import Map from './Map';
import Task from './TaskManager/Task'

const SubTask = (props) => {
  const { active, dataId } = props;
  return (
    <div className={`sub-task-item ${active ? 'active' : ''}`} data-id={dataId}>
    </div>
  )
}

class TasksList extends Component {
  constructor() {
    super();
    this.state = {
      activeSubTask: null
    }
  }

  componentDidMount() {
    const { actions } = this.props;

    actions.getWeather();
  }

  render() {
    const { tasks } = this.props;

    return (
      <Fragment>
        <div className="monitor-wrapper">
          <div className="task-list-container">
            {tasks.map(task => <Task key={task.id} task={task} />)}
          </div>
          <Map />
        </div>
      </Fragment>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    weatherState: state.weather,
    tasks: state.tasks.tasks,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    actions: new Actions(dispatch)
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(TasksList);