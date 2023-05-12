import { useEffect, useState } from 'react'
import { NewTodoForm } from './NewTodoForm'
import './styles.css'
import { TodoList } from './TodoList'

export default function App() {
  const [todos, setTodos] = useState(() => {
    const localValue = localStorage.getItem('ITEMS')
    if (localValue == null) return []

    return JSON.parse(localValue)
  })

  useEffect(() => {
    localStorage.setItem('ITEMS', JSON.stringify(todos))
  }, [todos])

  function addTodo(title) {
    setTodos((currentTodos) => {
      return [
        ...currentTodos,
        { id: crypto.randomUUID(), title, completed: false },
      ]
    })
  }

  function toggleTodo(id, completed) {
    setTodos((currentTodos) => {
      return currentTodos.map((todo) => {
        if (todo.id === id) {
          //todo.completed= completed  This is mutating my stata but the state is imutable
          // which means you can not change it and if you change it like this it is not going to work properly, you have to make sure evetytime you are changing your state,
          // you have to make sure you are not mutating and instead you are creating a brand new state object
          return { ...todo, completed } // here we are creating a brand new to do and just changing one property on it
        }

        return todo // return todo, because if it is not matching the current id, i just wanna return it as it was with no changes at all
      })
    })
  }

  function deleteTodo(id) {
    setTodos((currentTodos) => {
      return currentTodos.filter((todo) => todo.id !== id) // i want a filter version of the todos, which contains all my todos
      // expect the one that i want to remove
    })
  }

  return (
    <>
      <NewTodoForm onSubmit={addTodo} />
      <h1 className="header">Todo List</h1>
      <TodoList todos={todos} toggleTodo={toggleTodo} deleteTodo={deleteTodo} />
    </>
  )
}
