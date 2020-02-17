<template>
  <div class="edit">
    <form @submit="putBlog">
      <textarea class="form-control title" v-model="title" placeholder="Enter Title here"></textarea>
      <textarea class="form-control tags" v-model="tags" placeholder="Enter Tags here"></textarea>
      <editor v-bind:content="content" @onUpdate="onEditorContentUpdate" :key="id"></editor>
      <input type="checkbox" id="ispublished" v-model="isPublished" />
      <label for="ispublished">Review and Publish?</label>
      <br />
      <button class="btn btn-success">Save</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import editor from "./Editor";

export default {
  name: "blog",
  components: {
    editor
  },
  data() {
    return {
      id: "",
      title: "",
      content: "",
      tags: "",
      isPublished: Boolean
    };
  },
  methods: {
    getBlog() {
      const path =
        process.env.VUE_APP_API_PATH + "blogs/" + this.$route.params.id;
      axios
        .get(path)
        .then(res => {
          this.id = res.data.id;
          this.title = res.data.title;
          this.content = res.data.content;
          this.tags = res.data.tags;
          this.isPublished = res.data.isPublished;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
          this.$alert(
            "Something went wrong. Try again later!",
            "Error",
            "error"
          );
        });
    },
    async putBlog(e) {
      e.preventDefault();
      const path =
        process.env.VUE_APP_API_PATH + "blogs/" + this.$route.params.id;
      const token = await this.$auth.getTokenSilently();
      axios
        .put(
          path,
          {
            id: this.$route.params.id,
            title: this.title,
            content: this.content,
            tags: this.tags,
            updatedBy: this.$auth.user.name,
            isPublished: this.isPublished
          },
          {
            headers: {
              Authorization: `Bearer ${token}`
            }
          }
        )
        .then(res => {
          this.$alert("Article Saved", "Success", "success");
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
          this.$alert(
            "Something went wrong. Try again later!",
            "Error",
            "error"
          );
        });
    },
    onEditorContentUpdate(editorContent) {
      this.content = editorContent;
    }
  },
  created() {
    this.getBlog();
  }
};
</script>

<style scoped>
.title {
  font-size: 2rem;
  font-weight: 600;
  color: #222222;
}
.tags {
  margin-top: 1%;
  color: coral;
  font-weight: 400;
}
</style>
