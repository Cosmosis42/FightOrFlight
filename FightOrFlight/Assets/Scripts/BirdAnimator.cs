﻿using UnityEngine;
using System.Collections;

public class BirdAnimator : MonoBehaviour
{
	public enum BirdAnimations
	{
		Idle,
		Fly,
		Flap,
		Hurt,
		Dash,
		Dead
	}

	public BirdAnimations currentAnimation;        // Animation that is currently playing.

	public Animator Animator;                // The animator you want to use.
	public BirdController birdController;

	void Update()
	{
		AnimationUpdate(birdController.GetBirdState());
	}


	void AnimationUpdate(BirdAnimations birdState)
	{
		switch (birdState)
		{
			case BirdAnimations.Idle:
				TransitionTo(BirdAnimations.Idle, "bird_idle");
				break;
			case BirdAnimations.Fly:
				TransitionTo(BirdAnimations.Fly, "bird_fly");
				break;
			case BirdAnimations.Flap:
				TransitionTo(BirdAnimations.Flap, "bird_flap");
				break;
			case BirdAnimations.Hurt:
				TransitionTo(BirdAnimations.Hurt, "bird_hurt");
				break;
			case BirdAnimations.Dash:
				TransitionTo(BirdAnimations.Dash, "bird_dash");
				break;
			case BirdAnimations.Dead:
				TransitionTo(BirdAnimations.Dead, "bird_dead");
				break;
			default:
				TransitionTo(BirdAnimations.Idle, "bird_idle");
				break;
		}
	}

	// Set the animation enum, Name of the animation you want to play.
	void TransitionTo(BirdAnimations anim, string name)
	{
		// Check if the animation is already playing or not/
		if (currentAnimation != anim)
		{
			Animator.Play(name);
			currentAnimation = anim;
		}
	}
}