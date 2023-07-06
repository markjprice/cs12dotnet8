namespace Packt.Shared;

public interface IPlayable
{
  void Play();
  void Pause();
  void Stop() // Default interface implementation.
  {
    WriteLine("Default implementation of Stop.");
  }
}
