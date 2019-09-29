<template>
  <div class="list">
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Title</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(blog, index) in blogs" :key="index">
          <td>{{ blog.title }}</td>
          <td>
            <div class="btn-group" role="group">
              <router-link :to="'/edit/' + blog.id">
                <button type="button" class="btn btn-warning btn-sm">Update</button>
              </router-link>
              <button
                type="button"
                class="btn btn-danger btn-sm"
                v-on:click="deleteBlog(blog.id,$event)"
              >Delete</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "list",
  data() {
    return {
      blogs: []
    };
  },
  methods: {
    getBlogs() {
      const path = "https://localhost:5001/api/blogs";
      axios
        .get(path)
        .then(res => {
          this.blogs = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    deleteBlog(id, event) {
      const path = "https://localhost:5001/api/blogs/" + id;
      axios
        .delete(path)
        .then(res => {})
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  },
  created() {
    this.getBlogs();
  }
};
</script>

<style scoped>
</style>
