import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Bienvenido a tu nueva aplicación favorita para organizar tus tareas, estas son las funcionalidades que podras explorar:</p>
        <ul>
            <li>Agregar Tarea</li>
            <li>Listar Tareas</li>
            <li>Marcar como Completada</li>
            <li>Eliminar Tarea</li>
        </ul>
        <p>Debes inciar sesión para utilizar las funcionalidades.</p>
      </div>
    );
  }
}
