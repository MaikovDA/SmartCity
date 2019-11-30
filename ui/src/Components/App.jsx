import React, { Component, Fragment } from 'react';
import TasksList from './TasksList'
import Map from './Map'

export default class App extends Component {
    render() {
        return (
            <Fragment>
                <TasksList/>
                <Map/>
            </Fragment>
        );
    }
}
