import { useState, useEffect } from 'react'
import './Styles.css'

export default function App() {
  const [newItem, setNewItem] = useState('')
  // const [todos, setTodos] = useState([])
  const [todos, setTodos] = useState(() => {
    const localValue = localStorage.getItem('ITEMS')
    if (localValue == null) return []

    return JSON.parse(localValue)
  })

  useEffect(() => {
    localStorage.setItem('ITEMS', JSON.stringify(todos))
  }, [todos])

  function handleSubmit(e) {
    e.preventDefault()
    if (newItem === '') return
    setTodos((currentTodos) => {
      return [
        ...currentTodos,
        { id: crypto.randomUUID(), title: newItem, compeleted: false },
      ]
    })

    setNewItem('')
  }

  function toggleTodo(id, compeleted) {
    setTodos((currentTodos) => {
      return currentTodos.map((todo) => {
        if (todo.id === id) {
          return { ...todo, compeleted }
        }
        return todo
      })
    })
  }

  function deleteTodo(id) {
    setTodos((currentTodos) => {
      return currentTodos.filter((todo) => todo.id !== id)
    })
  }
  return (
    <>
      <form onSubmit={handleSubmit} className="new-item-form">
        <div className="form-row">
          <label htmlFor="item">New Item</label>
          <input
            value={newItem}
            onChange={(e) => setNewItem(e.target.value)}
            type="text"
            id="item"
          />
        </div>
        <button className="btn">Add</button>
      </form>
      <h1 className="header">Todo List</h1>
      <ul className="list">
        {todos.length === 0 && 'No Todos'}
        {todos.map((todo) => {
          return (
            <li key={todo.id}>
              <label>
                <input
                  type="checkbox"
                  checked={todo.compeleted}
                  onChange={(e) => toggleTodo(todo.id, e.target.checked)}
                />
                {todo.title}
              </label>
              <button
                onClick={() => deleteTodo(todo.id)}
                className="btn btn-danger"
              >
                Delete
              </button>
            </li>
          )
        })}
      </ul>
    </>
  )
}
