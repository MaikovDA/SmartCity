import React, { Component } from 'react';
import '../Styles/TasksList.scss';
import { connect } from 'react-redux';
import Actions from '../reducers/Actions';

const Task = (props) => {
  const { active, dataId } = props;
  return (
    <div className={`task-item ${active ? 'active' : ''}`} data-id={dataId}>
    </div>
  )
}

class TasksList extends Component {
  constructor() {
    super();
    this.state = {
      activeTask: null
    }
  }

  componentDidMount() {
    const { actions } = this.props;

    actions.getWeather();
  }

  handleClick = (e) => {

    const taskId = e.target.dataset.id;
    const { activeTask } = this.state;

    if (taskId !== undefined) {
      this.setState({
        activeTask: taskId === activeTask ? null : taskId
      })
    }
  }

  render() {
    const { activeTask } = this.state;
    const { weatherState, tasks } = this.props;

    return (
      <div className="task-list-container" onClick={this.handleClick}>
        {tasks.map(task => <Task key={task.id} dataId={task.id} active={task.id === activeTask} />)}
      </div>
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