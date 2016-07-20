<?php

class HomeController extends BaseController
{
    function index() {
         $posts= $this->posts =$this->model->getLatestPosts(5);
         $this->posts = array_slice($posts, 0 , 3);
         $this->postsSidebar = $posts;
    }
	
	function view($id) {
         $post= $this->model->getPostById($id);
        if(!$post) {
            $this->addErrorMessage("Invalid post id.");
            $this->redirect("");
        }
        $this->post = $post;
    }
}
