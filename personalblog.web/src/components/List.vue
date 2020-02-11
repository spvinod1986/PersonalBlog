<template>
  <div class="list">
    <div class="blog-list">
      <table class="table table-hover">
        <thead>
          <tr>
            <th scope="col">BLOGS</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(blog, index) in pageOfBlogs" :key="index">
            <td>{{ blog.title }}</td>
            <td class="blog-action">
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
    <div class="blog-page">
      <jw-pagination :items="blogs" @changePage="onChangePage" :labels="customLabels" :maxPages="5"></jw-pagination>
    </div>
  </div>
</template>

<script>
import axios from "axios";

const customLabels = {
  first: "<<",
  last: ">>",
  previous: "<",
  next: ">"
};

export default {
  name: "list",
  data() {
    return {
      blogs: [],
      pageOfBlogs: [],
      customLabels
    };
  },
  methods: {
    getBlogs() {
      const path = process.env.VUE_APP_API_PATH + "blogs";
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
    async deleteBlog(id, event) {
      const path = process.env.VUE_APP_API_PATH + "blogs/" + id;
      const token = await this.$auth.getTokenSilently();
      axios
        .delete(path, {
          headers: {
            Authorization: `Bearer ${token}`
          }
        })
        .then(res => {})
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    onChangePage(pageOfBlogs) {
      this.pageOfBlogs = pageOfBlogs;
    }
  },
  created() {
    this.getBlogs();
  }
};
</script>

<style scoped>
.blog-page {
  background-color: white;
  text-align: center;
}
.blog-action {
  text-align: right;
}
</style>
