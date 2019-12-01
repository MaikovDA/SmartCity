const initialState = {
  "tasks": [
    {
      "id": "gg_t_221tg",
      "name": "Задача 1",
      "status_name": "В очереди",
      "status_type": "error",
      "alerts": [
        {
          "type": "error",
          "text": "Поломка машины"
        }
      ],
      "subtasks": [
        {
          "id": "df35-df1d3f_s4",
          "name": "Подзадача 1",
          "status": "В очереди",
          "work_type": "Убрать снег",
          "work_type_id": "sdf_fds2",
          "attachment": "бункер",
          "start_time": "21:00",
          "deadline_time": "00:00",
          "coordinates": [
            [55.76113, 37.736136],
            [55.779783, 37.742258],
            [55.762043, 37.715592]
          ],
          "route_name": "Маршрут 1",
          "transport": "К-700",
          "driver": "Василий Пупкин"
        }
      ]
    },
    {
      "id": "gg_t_221tgdf",
      "name": "Задача 2",
      "status_name": "В работе",
      "status_type": "in-progress",
      "alerts": [],
      "subtasks": [
        {
          "id": "df35-df1_d3f_s4",
          "name": "Подзадача 1",
          "status": "В работе",
          "work_type": "Посыпать реагенты",
          "work_type_id": "sdf_fds2",
          "material": "реагент 1",
          "material_id": "jkl3_3gj__",
          "attachment": "бункер",
          "start_time": "21:00",
          "deadline_time": "00:00",
          "coordinates": [
            [55.76113, 37.736136],
            [55.779783, 37.742258],
            [55.762043, 37.715592]
          ],
          "route_name": "Маршрут 2",
          "transport": "КамАЗ",
          "driver": "Василий Пупкин"
        },
        {
          "id": "df35-df1d-3f_s4",
          "name": "Подзадача 2",
          "status": "В очереди",
          "work_type": "Убрать снег",
          "work_type_id": "sdf_fds2",
          "material": "реагент 1",
          "material_id": "jkl3_3g_j",
          "attachment": "бункер",
          "start_time": "21:00",
          "deadline_time": "00:00",
          "coordinates": [
            [55.76113, 37.736136],
            [55.779783, 37.742258],
            [55.762043, 37.715592]
          ],
          "route_name": "Маршрут 3",
          "transport": "К-700",
          "driver": "Василий Пупкин"
        }
      ]
    }
  ]
};

export default function tasksReduser(state = initialState, action) {
  switch (action.type) {
    case 'GET_TASKS':
      return { ...action.payload };
    default:
      return state;
  }
};
