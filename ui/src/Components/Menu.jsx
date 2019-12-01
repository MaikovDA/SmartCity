import React, { Component } from 'react';
import { connect } from 'react-redux';
import User from '../assets/user.png'
import Setting from '../assets/Setting'
import Monitor from '../assets/Monitor'
import Message from '../assets/Message'
import Manager from '../assets/Manager'
import '../Styles/Menu.scss'
import Actions from '../reducers/Actions';

class Menu extends Component {

  handleClick = (tabName) => {
    this.props.actions.setActiveTab(tabName)
  }

  render() {
    const { activeTab } = this.props;

    return (
      <div className="left-menu-panel">
        <img src={User} alt="user-avatar" className="user-avatar" />

        <div className="menu-items-wrapper">
          <div
            className={`item monitor ${activeTab === 'monitor' ? 'active' : ''}`}
            onClick={() => this.handleClick('monitor')}
          >
            <Monitor />
            <div className="item-header">Монитор</div>
          </div>
          <div
            className={`item manager ${activeTab === 'manager' ? 'active' : ''}`}
            onClick={() => this.handleClick('manager')}
          >
            <Manager />
            <div className="item-header">Планировщик</div>
          </div>
          <div
            className={`item notifications ${activeTab === 'notifications' ? 'active' : ''}`}
            onClick={() => this.handleClick('notifications')}
          >
            <Message />
            <div className="item-header">Уведомления</div>
          </div>
          <div
            className={`item setting ${activeTab === 'setting' ? 'active' : ''}`}
            onClick={() => this.handleClick('setting')}
          >
            <Setting />
            <div className="item-header">Настройки</div>
          </div>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    activeTab: state.activeTab,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    actions: new Actions(dispatch)
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Menu);