import React, { Component, Fragment } from 'react';
import Menu from './Menu';
import WeatherWidget from './WeatherWidget';
import TaskManager from './TaskManager/TaskManager';
import TasksList from './TasksList';
import { connect } from 'react-redux';

class App extends Component {
    render() {

        const { activeTab } = this.props;

        return (
            <Fragment>
                <Menu />
                {
                    activeTab === 'manager' &&
                    [
                        <TaskManager key="1" />,
                        <WeatherWidget key="2" />
                    ]
                }
                {
                    activeTab === 'monitor' && <TasksList />
                }
            </Fragment>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        activeTab: state.activeTab,
    };
};

export default connect(mapStateToProps)(App);