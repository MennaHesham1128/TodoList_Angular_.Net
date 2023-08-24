import { Component } from '@angular/core';
import { Todo } from './TodoModel';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  todoList: Todo[] = [];
  newTask: string;
  due: Date;
  saveTask(){
    if (this.newTask){
      let todo = new Todo();
      todo.Task = this.newTask;
      todo.dueDate = this.due;
      todo.isCompleted = true;
      this.todoList.push(todo);
      this.newTask = '';
    } else{
      alert("Please Enter a New Task")
    }
  }
  // checkCompleted(id:number){
  //   this.todoList[id].isCompleted = !this.todoList[id].isCompleted
  // }

  remove(id:number){
    this.todoList = this.todoList.filter((v,i)=> i !== id);
  }
  
}
