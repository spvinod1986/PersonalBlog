<template>
  <div class="create">
    <form @submit="postBlog">
      <textarea class="form-control" v-model="title" placeholder="Enter Title"></textarea>
      <!-- <textarea class="form-control" v-model="content" placeholder="Enter Summary"></textarea> -->
      <ckeditor :editor="editor" v-model="content" :config="editorConfig"></ckeditor>
      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import axios from "axios";

export default {
  name: "create",
  data() {
    return {
      title: "",
      content: "",
      editor: ClassicEditor,
      editorConfig: {
        // The configuration of the editor.
      }
    };
  },
  methods: {
    postBlog(e) {
      e.preventDefault();
      const path = "https://localhost:5001/api/blogs";
      axios
        .post(path, {
          title: this.title,
          content: this.content
        })
        .then(res => {
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  }
};
</script>

<style scoped>
</style>
