import React, { Component, Fragment } from 'react';
import '../../Styles/TaskManager.scss';
import { connect } from 'react-redux';
import Actions from '../../reducers/Actions';
import Task from './Task';

const Popup = (props) => {
  return (
    <div className="popup_layout">
      <div className="popup_wrapper">
        <div className="popup_close" onClick={props.onClick}>X</div>
        <div className="body">
          Редактирование задания.
        </div>
      </div>
    </div>
  )
}

class TaskManager extends Component {
  constructor() {
    super();
    this.state = {
      showPopup: false
    }
  }

  componentDidMount() {
    const { actions } = this.props;
  }

  handleClick = () => {
    const { showPopup } = this.state;

    this.setState({
      showPopup: !showPopup
    })
  }

  render() {
    const { showPopup } = this.state;
    const { tasks } = this.props;

    return (
      <Fragment>
        <div className="task-list">
          <div className="header">Планировщик заданий</div>
          {tasks.map(task => <Task key={task.id} task={task} edited={true} showPopup={this.handleClick} />)}
        </div>
        {showPopup && <Popup onClick={this.handleClick} />}
      </Fragment>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    tasks: state.tasks.tasks,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    actions: new Actions(dispatch)
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(TaskManager);