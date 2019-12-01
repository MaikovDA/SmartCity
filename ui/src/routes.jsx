import React from 'react';
import {Route, Switch} from 'react-router-dom';
import TaskManagerController from './controllers/TaskManagerController';
import TasksListController from './controllers/TasksListController';

const ApplicationRouter = (props) => (
	<Switch>
		<Route exact path='/' render={(d) => <TaskManagerController {...props} {...d}/>}/>
		<Route path='/tasks' render={(d) => <TasksListController {...props} {...d}/>}/>
	</Switch>
);

export default ApplicationRouter;
