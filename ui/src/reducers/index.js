import {combineReducers} from 'redux';
import mapReducer from './redusers/mapReducer';
import weatherRreducer from './redusers/weatherRreducer';
import tasksReduser from './redusers/tasksReduser';
import tabReduser from './redusers/tabReduser';

export default combineReducers({
	YAMapState: mapReducer,
	weather: weatherRreducer,
	tasks: tasksReduser,
	activeTab: tabReduser,
});
